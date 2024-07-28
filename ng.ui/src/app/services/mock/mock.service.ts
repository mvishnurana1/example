import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { baseUrl } from '../urls';
import { BehaviorSubject, catchError, Observable, of, startWith, tap } from 'rxjs';

export interface WeatherReport {

}

export class CustomerDto {
  email: string;
  name: string;
  role: string;
}

export class ErrorDto {
  loading = false;
  errorCode: string;
  message: string;
}

@Injectable({
  providedIn: 'root'
})
export class MockService {
  private weatherReports$ = new BehaviorSubject<WeatherReport[]>([]);

  constructor(
    private http: HttpClient
  ) { }

  getWeatherInfo(): Observable<WeatherReport[] | ErrorDto> {
    return this.http.get<WeatherReport[]>(`${baseUrl}WeatherForecast`).pipe(
      tap((res) => ({ loading: false, res })),
      catchError((error) => { console.log('logging error: ', error); return of({ loading: false, errorCode: '400', message: 'something went wrong' }) as Observable<ErrorDto> }),
      // startWith(() => { loading: true }),
    );
  }

  getCustomers(id: number): Observable<CustomerDto[] | ErrorDto> {
    if (!id) {
      return of({
        loading: false,
        errorCode: '400',
        message: 'No ID parameter passed'
      }) as Observable<ErrorDto>;
    }

    return this.http.get<CustomerDto[]>(`${baseUrl}WeatherForecast/${id}`).pipe(
      tap((res) => res),
      catchError((error: ErrorDto) => {
        console.log('logging error: ', error);
        return of({
          loading: false,
          errorCode: '400',
          message: 'something went wrong'
        }) as Observable<ErrorDto>
      }),
    );
  }
}
