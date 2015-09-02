Database Initialization ReadMe

Here we look at strageties for initializing a database for a Code First EF application.

Part A: Built-In Initializers

1. Insert static ctor on SampleContext to call set database initializer
   - Database.SetInitializer ...
	 CreateDatabaseIfNotExists
	 DropCreateDatabaseAlways
	 DropCreateDatabaseIfModelChanges
	 NullDatabaseInitializer

2. Try different init strategies

Part B: Custom Initializer to Seed Data

1. Add SampleInitializer class that extends CreateDatabaseIfNotExists<SampleContext>
   - Override the Seed method to add data

2. Set database initializer to SampleInitializer in SampleContext static ctor

