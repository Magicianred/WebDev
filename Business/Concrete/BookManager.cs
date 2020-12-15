using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class BookManager : IBookService // bir kitap eklemek için veri erişim katmanına ihtiyaac var 
    {
        private IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public void Add(Book book)
        {
            // kitap eklerken kurallar varsa buraya yazılır.
            // İş kodu

            if (_bookDal.Get(b=>b.Name == book.Name && book.AuthorId == book.AuthorId) == null)
            {
                _bookDal.Add(book);
            }
            else
            {
                throw new Exception("Bu kitap adı zaten mevcut...");
            }
            
            
        }

        public void Delete(Book book)
        {
            _bookDal.Delete(book);
        }

        public List<Book> GetAll()
        {
            return _bookDal.GetList().ToList();
        }

        public List<Book> GetByAuthorId(int id)
        {
            return _bookDal.GetList(b => b.AuthorId == id).ToList();
        }

        public Book GetById(int id)
        {
            return _bookDal.Get(b => b.Id == id);
        }

        public void Update(Book book)
        {
            _bookDal.Update(book);
        }
    }
}
