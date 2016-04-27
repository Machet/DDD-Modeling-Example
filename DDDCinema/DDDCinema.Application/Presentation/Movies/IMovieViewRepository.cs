using System;
using System.Collections.Generic;

namespace DDDCinema.Application.Presentation.Movies
{
    public interface IMovieViewRepository
    {
        List<MovieDTO> GetMovies(DateTime start);
        RoomDTO GetRoomBySeanse(int seanseId);
    }
}
