using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WcfMovieService
{

    [ServiceContract]
    public interface IMovieService
    {
        [OperationContract]
        bool AddMovie(Movie movie);

        [OperationContract]
        List<Movie> GetAllMovies();

        [OperationContract]
        Movie GetMovieById(int id);

        [OperationContract]
        bool UpdateMovie(Movie movie);

        [OperationContract]
        bool DeleteMovie(int id);
    }

    [DataContract]
    public class Movie
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Director { get; set; }

        [DataMember]
        public int Year { get; set; }
    }
}
