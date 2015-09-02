Entity Mapping ReadMe

Here we demonstrate various entity mapping strategies. We start with convention-based mappings
that can be customized.  Then we'll apply mapping attributes to our entities.  Lastly, we will
create custom mapping classes using a fluent mapping API and reverse engineering an existing
database.

Part A: Convention-Based Mapping

1. Select the Entity-Mapping project and press Ctrl+F5 to run it.
   - Enter Y to initialize the database
   - You'll get a model validation exception stating that Category and Product
	 have no key defined.  This is because the Key property is non-conventional.

2. Open MappingContext.cs and override OnModelCreating
   - Remove key discovery convention
   - Configure integer properties named 'Key' to be the entity key

3. Run the Entity-Mapping app again and enter 'Y' to initialize the database
   - Notice that Product.Price defaults to zero if no value is supplied,
	 because it is non-nullable.
   - Notice that Product.CategoryKey is properly mapped as a foreign key

4. Change Product.Price to nullable decimal
   - Use C# shorthand: decimal?
   - Delete the database before running the app and initializing the database
   - Notice this time that Price is blank (null) when no value is supplied

5. Lastly, notice that the database table names were pluralized.
   - We can change the mapping convention to use singular table names
   - Simply remove the pluralizing table name convention in OnModelCreating
   - Drop the database and re-initialize, then verify using SQL Mant Studio

Part B: Attribute-Based Mapping

1. Apply Table attribute to map Product entity to the PRODUCT table
   - Do the same for Category
   - You can delete code in OnModelCreating that removes the convention

2. Make Product.ProductName non-nullable, set min and max length
   - Use Required, MinLength(4), MaxLength(20) attributes

3. Map Product.ProductDescription to Description column with ntext data type
   - Use Column attribute

4. Add a DateCreated property to Product and map to database generated column
   - Use DatabaseGenerated(DatabaseGeneratedOption.Computed) attribute

5. Delete and re-initialize the database
   - You will get an error stating that DateCreated cannot accept a null value
   - Open SQL Mant Studio, right-click PRODUCT, select Design
   - Expand Computed Column Specification, enter getdate() into Formula
	 > If error, uncheck "Prevent saving changes that require table re-creation"
	   under Tools, Options, Designers
   - Run the app to initialize database and insert data
   - Use SQL Mant studio to view the PRODUCT table data
	 > See that DateCreated has now been populated

Part C: Code-based Mapping with Fluent API

1. Run the Entity-Mapping-Fluent project
   - If necessary set it as the startup project for the solution
   - You'll get a validation exception stating that keys are missing from entities

2. Add a CategoryMap class
   - Inherit from EntityTypeConfiguration<Category>
   - Add a ctor with mappings
	 > HasKey(t => t.CategoryIdentifier)

3. Add a ProductMap class
   - Do the same as CategoryMap

4. Override OnModelCreating in MappingContext
   - Add mapping classes to Configuration

5. Add mapping for singular table names
   - ToTable("Category")
   - ToTable("Product")

6. Add mappings to make Name properties non-nullable, with 20 max length
   - IsRequired
   - HasMaxLength(20)

7. Also add mapping for ProductDescription
   - HasColumnName("Description")
   - HasColumnType("ntext")

8. Delete and re-init the database
   - Use SQL Mant Studio, inspect table columns

Part D: Reverse Engineering with EF Power Tools

- Add the Entity Framework NuGet package to the Reverse-Engineer project.

1. Make sure you have installed the Entity Framework Power Tools extension
   - Tools, Extensions and Updates
   - EF 6.1 will replace the Power Tools with a consolidated model designer

2. Right-click on the Reverse-Engineer project, select Reverse Engineer Code First
   - Server Name: .\sqlexpress
   - Database Name: NorthwindSlim

3. Write some code to query categories and products
   - Inspect the generated entity and mapping classes
   - Note it is also possible to customize T4 tempates for code generation
   - By right-clicking on the context class, you can view the model and also
	 pregenerate views to improve performance
