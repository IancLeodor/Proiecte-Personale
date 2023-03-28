using Xunit;
using System;

namespace TestBook
{
    public class UnitTest1
    {
        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book1");
            var book2 = GetBook("Book2");

            Assert.Equal("Book1", book1.Name);
            Assert.Equal("Book2", book2.Name);
            Assert.NotSame(book1, book2);

        }
        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1=GetBook("Book1");
            var book2=GetBook("Book2");

            /*Assert.Equal("Book1", book1.Name);
            Assert.Equal("Book2",book2.Name);*/
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1,book2));

            

        }
        TestBook GetBook(string name)
        {
            return new TestBook(name);
        }

    }
}