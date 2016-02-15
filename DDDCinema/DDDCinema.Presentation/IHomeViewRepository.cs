using System;
using System.Collections.Generic;

namespace DDDCinema.Presentation
{
    public interface IMovieViewRepository
    {
        List<MovieDTO> GetMovies(DateTime start);
        RoomDTO GetRoomBySeanse(int seanseId);
    }
}
