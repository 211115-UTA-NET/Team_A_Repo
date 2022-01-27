import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Movie } from './mytypes';
import { Showtime } from './mytypes';
import { Tickets } from './mytypes';
import { SelectionAmounts } from './mytypes';

import { fakeMovie } from './melindas-fake-data';
import { fakeShowtime } from './melindas-fake-data';
import { fakeTickets } from './melindas-fake-data';
import { fakeTicketSelectionAmounts } from './melindas-fake-data';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  private url = "http://localhost:4200/PhoenixTheatre/filmShowings";
  getMovies(): Observable<Movie[]> {
    return this.http.get<Movie[]>(this.url);
  }

  getMovie(id: string): Observable<Movie> {
    const movie = fakeMovie.find(m => m.filmName === id)!;
    return of(movie);
  }

  getShowTimes(): Observable<Showtime[]> {
    const showTimes = of(fakeShowtime);
    return showTimes;
  }

  getShowTime(id: number): Observable<Showtime> {
    const showtime = fakeShowtime.find(s => s.filmShowingsId === id)!;
    return of(showtime);
  }

  getTickets(): Observable<Tickets[]> {
    const tickets = of(fakeTickets);
    return tickets;
  }

  constructor(private http: HttpClient) { }
}
