import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MockService } from './services/mock/mock.service';
import { Observable } from 'rxjs';

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

  constructor(
    private mockService: MockService,
  ) { }

  ngOnInit(): void {
    this.response$ = this.mockService.getWeatherInfo().;

    this.response$
  }
}
