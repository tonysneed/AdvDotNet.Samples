Persisting Changes ReadMe

This project demonstrates how to using a Code First project to persist entity changes
back to the database.

The SampleContext specifies a database name of PersistingChanges, which will be
created the first time the application is run.

Part A: Inserts

1. Creating a using block in Program.Main with a new SampleContext
   - Log SQL to the Console

2. Prompt the user for a new product name and price

3. Add a new Product and save changes.

4. Print out the new product info to the Console.
   - Note the value of Id which was generated by the database
   - Note SQL that was executed and that it includes both an
     INSERT and a SELECT statement

Part B: Updates

1. Prompt user to press Enter to increase the price.

2. Increment product price and save changes on the context.

Part C: Deletes

1. Prompt user to delete product

2. Remove product from context.Products

3. Save changes

