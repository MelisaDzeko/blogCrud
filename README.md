After you clone this repository. You need to start you SQL server and 
create an empty database with the name "RubiconDB".

- Open NuGet packet manager console and run the commands:
	- add-migration initial
	- update-database

Default data should be seeded. When you run the app you should open a swagger page for testing.

I implemented all method that was required:
- get multiple blogPosts with optional parameter (filter blogPosts by tag)
- get single blogPost
- create blogPost
- update blogPost
- delete blogPost 
- getTags
