# Timestamped Entity

## Package goal

This package simplify the implementation of **timestamped entities** with DbContext (EF).

Some entities need to record the creation and the updated dates and it is a kind of technical data that could be hidden from the business code.  

## How to use it ? 

- Inherit your custom entity from `TimestampedEntity`

```c#
public class FooEntity : TimestampedEntity
{
   
}
```

- Inherit your DbContext from `TimeStampedDbContext`

```c#
public class ApplicationDbContext : TimeStampedDbContext
{
   
}
```

- Create a new data migration : https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli


## Result 

Your `FooEntity` will have 2 new `Datetime` property (`CreatedOn` and `UpdatedOn`) that will be automatically set during `Add` or `Update`transaction call (thanks to `TimeStampedDbContext`).