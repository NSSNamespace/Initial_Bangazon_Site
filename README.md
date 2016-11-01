Bangazon!
===

## An online retailer

**Bangazon Inc** is an online retailer that allows users to buy and sell their products.

## Features
#### Our users are able to
- register as a Bangazon customer
- add products to be sold from Bangazon
- purchase products listed by other Bangazon customers

## Getting Started

You must have [Microsoft .net framework](https://www.microsoft.com/en-us/download/details.aspx?id=30653) and [Bower](https://bower.io/) to run this project.

[SQLite](https://sqlite.org/) is the database our project uses.

##### to fork project:
[Fork here](https://github.com/NSSNamespace/Initial_Bangazon_Site)

##### to clone project

```git clone https://github.com/NSSNamespace/Initial_Bangazon_Site.git```

##### set path where database will be saved
###### OSX/Linux:
```export Bangazon_Db_Path="/path/to/bangazon.db"```

###### Windows:
```$env: Bangazon_Db_Path="/path/to/bangazon.db"```

##### run the following commands

```Bash
dotnet ef database update
dotnet restore
bower install
dotnet run
```

##### to view project
Navigate to [localhost:5000](localhost:5000) in your browser