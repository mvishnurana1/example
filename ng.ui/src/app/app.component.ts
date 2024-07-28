import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CustomerDto, ErrorDto, MockService } from './services/mock/mock.service';
import { tap } from 'rxjs';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  title = 'ng.ui';
  response$: any;
  customerResponse: CustomerDto[] | ErrorDto;

  constructor(
    private mockService: MockService,
  ) { }

  ngOnInit(): void {
    this.response$ = this.mockService.getWeatherInfo();

    console.log(this.response$);

    this.mockService.getCustomers(4).pipe(
      tap((res: CustomerDto[] | ErrorDto) => {
        this.customerResponse = res;
        console.log(this.customerResponse);
      }),
    ).subscribe();
  }
}
