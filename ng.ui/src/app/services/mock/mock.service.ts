import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { baseUrl } from '../urls';
import { BehaviorSubject, catchError, Observable, of, startWith, tap } from 'rxjs';

export interface WeatherReport {

}

@Injectable({
  providedIn: 'root'
})
export class MockService {
  private weatherReports$ = new BehaviorSubject<WeatherReport[]>([]);

  constructor(
    private http: HttpClient
  ) { }

  getWeatherInfo(): Observable<WeatherReport[]> {
    // return this.http.get(`${baseUrl}WeatherForecast`).pipe(
    //   tap((res) => ({ loading: false, res })),
    //   catchError((error) => of({ loading: false, error })),
    //   startWith(() => { loading: true })
    // )
    return of([1, 2, 3]);
  }
}
