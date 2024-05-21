using sa.gov.libgph.MedadApi.Models.Response;
using sa.gov.libgph.Services.Response;
using System.Linq;

namespace sa.gov.libgph.Services.Converter
{
    public class GiftedBookConverter
    {
        public SearchResponse getSearchResponse(GiftedBookResponse giftedBookResponse)
        {
            var searchResponse = new SearchResponse();
            foreach (var giftedBook in giftedBookResponse.data)
            {
                var contributor = new Contributor()
                {
                    name = giftedBook.authorName,
                    contributorNameTypeId =string.Empty ,
                    primary = false

                };

                var publication = new Publication()
                {
                    dateOfPublication = giftedBook.publicationDate.ToShortDateString(),
                    publisher=giftedBook.publisherName,
                    

                };
                var instance = new Instance()
                {

                    title = giftedBook.bookTitle,
                    id = giftedBook.id.ToString(),
                    discoverySuppress = false,
                    staffSuppress = false,
            



                };
                instance.contributors.ToList().Add(contributor);
                instance.publication.ToList().Add(publication);

            }

            return searchResponse;
        }
    }
}