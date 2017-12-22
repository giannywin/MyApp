namespace MyApp.Models
{
    public class ListRecord<T>
    {
        public RowProperties RowProperties { get; set; }

        public T Record { get; set; }
    }
}
