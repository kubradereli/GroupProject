using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BookAddValidator:AbstractValidator<ReadBook>
    {
        public BookAddValidator()
        {
            RuleFor(x => x.Book.BookName).NotEmpty().WithMessage("Kitap adını giriniz."); ;
            RuleFor(x => x.Book.BookAuthor).NotEmpty().WithMessage("Kitap yazarını giriniz."); ;
            RuleFor(x => x.Book.BookPageCount).NotEmpty().WithMessage("Kitap sayfa sayısını giriniz."); 
            RuleFor(x => x.Book.BookPublishingHouse).NotEmpty().WithMessage("Kitap yayınevini giriniz.");
            RuleFor(x => x.ReadingDate).NotEmpty().WithMessage("Okuduğunuz tarihi giriniz");
            RuleFor(x => x.ReadBookReviewPoint).NotEmpty().WithMessage("Kitap puanını giriniz.");
            RuleFor(x => x.ReadBookReviewPoint).InclusiveBetween(1,10).WithMessage("Kitap puanını 1-10 arası giriniz.");
            
        }
    }
}
