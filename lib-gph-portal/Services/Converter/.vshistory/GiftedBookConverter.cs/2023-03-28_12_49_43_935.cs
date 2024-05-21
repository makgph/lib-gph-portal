using sa.gov.libgph.MedadApi.Models.Response;
using sa.gov.libgph.Services.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sa.gov.libgph.Services.Converter
{
    public class GiftedBookConverter
    {
         public SearchResponse getSearchResponse(GiftedBookResponse giftedBookResponse)
        {
            var ll = new SearchResponse()
            {



            };
            foreach (var giftedBook in giftedBookResponse.data)
            {
                var contributor = new Contributor() {
                    name = giftedBook.authorName,
                    
                };
                var instance = new Instance() {

                    title = giftedBook.bookTitle,
                    id=giftedBook.id.ToString(),
                   

                
                
                };
                instance.contributors.ToList().Add(contributor);
                
            }

            return ll;
        }
    }
}