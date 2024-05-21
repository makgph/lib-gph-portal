namespace sa.gov.libgph.MedadApi.Models.Request
{
    public class AdvancedSearchRequestModel
    {

        public Input First { get; set; }
        public Input Second { get; set; }
        public Input Third { get; set; }
        public Input Forth { get; set; }
        public Input Fifth { get; set; }
        public Input Sixth { get; set; }
        public string LibraryName { get; set; }
        public string ScoutGeneral { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public string Series { get; set; }
        public string BowlType { get; set; }
        public string SubjectStatus { get; set; }
        public string PublicationDate { get; set; }
        public string SortBy { get; set; }
        public string ResolveQuery()
        {
            var q1 = "";
            var q2 = "";
            var opeartion2 = " or ";


            if (First != null && !string.IsNullOrEmpty(First.input) && !string.IsNullOrEmpty(First.type))
            {
                q1 += $"{First.type}=={First.input} ";
            }

            if (Second != null && !string.IsNullOrEmpty(Second.input) && !string.IsNullOrEmpty(Second.type) && !string.IsNullOrEmpty(First.nextOperation))
            {
                q1 += $"{First.nextOperation} {Second.type}=={Second.input} ";
            }

            if (Third != null && !string.IsNullOrEmpty(Third.input) && !string.IsNullOrEmpty(Third.type) && !string.IsNullOrEmpty(Second.nextOperation))
            {
                q1 += $"{Second.nextOperation} {Third.type}=={Third.input} ";
            }

            if (Forth != null && !string.IsNullOrEmpty(Forth.input) && !string.IsNullOrEmpty(Forth.type) && !string.IsNullOrEmpty(Third.nextOperation))
            {
                q1 += $"{Third.nextOperation} {Forth.type}=={Forth.input} ";
            }

            if (Fifth != null && !string.IsNullOrEmpty(Fifth.input) && !string.IsNullOrEmpty(Fifth.type) && !string.IsNullOrEmpty(Forth.nextOperation))
            {
                q1 += $"{Forth.nextOperation} {Fifth.type}=={Fifth.input} ";
            }
            if (Sixth != null && !string.IsNullOrEmpty(Sixth.input) && !string.IsNullOrEmpty(Sixth.type) && !string.IsNullOrEmpty(Fifth.nextOperation))
            {
                q1 += $"{Fifth.nextOperation} {Sixth.type}=={Sixth.input}";
            }


            if (!string.IsNullOrEmpty(LibraryName))
            {
                var currentOperation = q2.Length == 0 ? "" : opeartion2;
                q2 += $"{currentOperation} items.effectiveLocationId == {LibraryName} ";
            }

            if (!string.IsNullOrEmpty(BowlType))
            {
                var currentOperation = q2.Length == 0 ? "" : opeartion2;
                q2 += $"{currentOperation} items.materialTypeId == {BowlType} ";
            }
            if (!string.IsNullOrEmpty(SubjectStatus))
            {
                var currentOperation = q2.Length == 0 ? "" : opeartion2;
                q2 += $"{currentOperation}  SubjectStatus == {SubjectStatus} ";
            }
            if (!string.IsNullOrEmpty(PublicationDate))
            {
                var currentOperation = q2.Length == 0 ? "" : opeartion2;
                q2 += $"{currentOperation}  PublicationDate == {PublicationDate} ";
            }
            if (!string.IsNullOrEmpty(SortBy))
            {
                SortBy = $"sortby {SortBy}";
            }
            //if (!string.IsNullOrEmpty(ScoutGeneral))
            //{
            //    q2 += $"{opeartion2} ScoutGeneral={ScoutGeneral} ";
            //}
            //if (!string.IsNullOrEmpty(Author))
            //{
            //    q2 += $"{opeartion2} contributors.name={Author} ";
            //}
            //if (!string.IsNullOrEmpty(Title))
            //{
            //    q2 += $"{opeartion2} title =={Title} ";
            //}
            //if (!string.IsNullOrEmpty(Subject))
            //{
            //    q2 += $"Subject={Subject}{opeartion2}";
            //}
            //if (!string.IsNullOrEmpty(Series))
            //{
            //    q2 += $"Series={Series}{opeartion2}";
            //}

            var Query = "(" + q1 + (q1.Length == 0 || q2.Length == 0 ? "" : " and ") + q2 + ") " + SortBy;
            return Query;
        }

    }

    public class Input
    {
        public string input { get; set; }
        public string type { get; set; }
        public string nextOperation { get; set; }
    }
}