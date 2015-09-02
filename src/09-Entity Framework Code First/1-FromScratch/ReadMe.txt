Code First from Scratch ReadMe

This project demonstrates how to create an EF Code First application from scratch.
First we will create entity and context classes, with a database that will be created
the first time the app is launched, using the default connection factory for SQL Express.

Part A: Entity and Context Classes

1. First add the Entity Framework NuGet package.

2. Then add entity classes for Category and Project
   - Category: Id (int), CategoryName (string), Products (List<Product>)
   - Product: Id (int), ProductName (string), Price (decimal), CategoryId (int), Category (Category)

3. Add a SampleContext class
   - Add a ctor that calls base ctor, passing "HelloCodeFirst" for the database name
   - Add properties for Categories and Products (DbSet<T>)

4. Write code in a Seed Data method to create these categories:
   - Beverages, Condiments, Confections
   - Keep a reference to each created category

5. And to create these products:
   - Beverages: Chai (10), Chang (20), Ipoh Coffee (30)
   - Condiments: Aniseed Syrup (40)
   - Confections: Chocolade (50), Maxilaku (60)
   - Set Category to referenced category

6. Run the program, calling SeedData from Main
   - Open SQL Management Studio to inspect the newly created database with seeded data
   - Notice that the database is created when a DbSet is first accessed

7. Write code in Main to query categories, then products by category
   - Comment out call to SeedData method after running for the first time

Part B: Default Connection Factory

1. Change the default connection factory from SQL Express to LocalDb
   - Comment out defaultConnectionFactory element in app.config
   - Add the following:
	<defaultConnectionFactory type="System.Data.Entity.Infrastructure.LocalDbConnectionFactory, EntityFramework">
	  <parameters>
		<parameter value="v11.0"/>
	  </parameters>
	</defaultConnectionFactory>

2. Run the code that initializes the database
   - Connect to (LocalDb)\v11.0 with SQL Server Mant Studio
   - Verify that the database was created

Part C: Code-Based Configuration

1. Comment out section of defaultConnectionFactory section of config
   - If present in config file, will take precedence over code-based config

2. Add a SampleConfiguration class to the project
   - Derive from DbConfiguration
   - Add a parameterless ctor
   - Call SetDefaultConnectionFactory(new LocalDbConnectionFactory("v11.0"))

3. Run the app and check for db creation using SQL Server Mant Studio
   - EF will use DbConfiguration class automatically

Part D: Connection Strings

1. Insert a connection string into app.config
  <connectionStrings>
	<add name="SampleContext"
		 connectionString="Data Source=(local)\sqlexpress;Initial Catalog=HelloCodeFirst;Integrated Security=True;MultipleActiveResultSets=True"
		 providerName="System.Data.SqlClient" />
  </connectionStrings>

2. Change the ctor of SampleContext to use the connection string name
   - name=SampleContext

Part E: Lazy Loading

1. Write code that gets a category by id and then prints related products
   - Also get a product by id and print related category name
   - Add code to log SQL to the console window
   - Running the code should product a null reference exception

2. Enable lazy loading
   - Add code to the context ctor to enable lazy loading
	 Configuration.LazyLoadingEnabled = true
   - You shoud still get a null reference exception

3. Make navigation properties virtual
   - Category.Products
   - Product.Category
   - The null reference exception should go away at this point

4. Notice how getting a product for the selected category does not require
   another trip to the database
   - But getting a product for a different category does

