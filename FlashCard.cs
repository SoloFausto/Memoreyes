namespace Memoreyes {
    public class FlashCard {
        public string Title { get; set;}
        public string Description { get; set;}
        public FlashCard(string Title, string Description) { 
            this.Title = Title;
            this.Description = Description;
        }
    }
}
