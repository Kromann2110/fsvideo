using infra;
using LinqToDB;
using LinqToDB.Data;

public class MyDatabaseConnection : DataConnection
{
    public MyDatabaseConnection(DataOptions<MyDatabaseConnection> options) : base(options.Options)
    {
    }

    public ITable<Book> Books => this.GetTable<Book>();
    public ITable<Author> Authors => this.GetTable<Author>();
}