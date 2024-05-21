using sa.gov.libgph.MedadApi.Models.Response;
using sa.gov.libgph.Services.Response;
using System.Collections.Generic;

namespace sa.gov.libgph.Services.Converter
{
    public class GiftedBookConverter
    {
        public SearchResponse getSearchResponse(GiftedBookResponse giftedBookResponse)
        {
            var searchResponse = new SearchResponse();
            searchResponse.instances = new Instance[] { };

            var InstanceList = new List<Instance>();

            foreach (var giftedBook in giftedBookResponse.data)
            {
                var ContributorList = new List<Contributor>();

                var contributor = new Contributor()
                {
                    name = giftedBook.authorName,
                    contributorNameTypeId = string.Empty,
                    primary = false

                };
                ContributorList.Add(contributor);
                var PublicationList = new List<Publication>();
                var publication = new Publication()
                {
                    dateOfPublication = giftedBook.publicationDate.ToShortDateString(),
                    publisher = giftedBook.publisherName,


                };
                PublicationList.Add(publication);
                var instance = new Instance()
                {

                    title = giftedBook.bookTitle,
                    id = giftedBook.id.ToString(),
                    discoverySuppress = false,
                    staffSuppress = false,
                    contributors = new Contributor[] { },
                    publication = new Publication[] { }



                };
                instance.contributors = ContributorList.ToArray();
                instance.publication = PublicationList.ToArray();

                InstanceList.Add(instance);
            }
            searchResponse.instances = InstanceList.ToArray();
            return searchResponse;
        }
    }
}