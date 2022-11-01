# ShopperCsvParser
Hi!
Tool helps to migrate products data from yours Shoper stright to your DB.
It's console aplication in .net6.0.

## Exported data from Shoper
Products data can be exported as CSV file.
Where **;** is colum separator.
It might heppend you have used **;** somewhere in description. 
Be aware of it and fix spots which require attenction.

## DB
You can find DB project where table reflects columns in exported file.
Stored procetude also included to add data.

## Appsettings
You should provide connection sting and file path.

## Run app
You can run it using cmd for example:
dotnet DataMover.dll run

## P.S.
If this tools helps you somehow, I am happy to hear it.
