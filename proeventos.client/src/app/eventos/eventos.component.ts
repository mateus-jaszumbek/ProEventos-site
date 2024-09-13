import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrl: './eventos.component.scss'
})
export class EventosComponent implements OnInit {

  public eventos: any;

  constructor(private http: HttpClient) {
    this.getEventos()
  }

  ngOnInit(): void { }

  public getEventos(): void {
    this.http.get("https://localhost:7221/api/eventos").subscribe(
      response => this.eventos = response,
      error => console.log(error)
    );
  }
}
