import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrl: './eventos.component.scss'
})
export class EventosComponent implements OnInit {
  public eventos: any = [];
  public eventosFiltrados: any = [];

  exibiImagem = true;
  widthImg = 150;
  marginImg = 2;
  private _filtroLista = '';

  public get filtroLista(): string {
    return this._filtroLista
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  filtrarEventos(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLowerCase();
    return this.eventos.filter(
      (evento: any) =>
        evento.tema.toLowerCase().indexOf(filtrarPor) !== -1 || evento.local.toLowerCase().indexOf(filtrarPor) !== -1 || evento.dataEvento.indexOf(filtrarPor) !== -1
    );
  }
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos()
  }

  alterarImagem() {
    this.exibiImagem = !this.exibiImagem;
  }

  public getEventos(): void {
    this.http.get("https://localhost:7221/api/eventos").subscribe(
      response => {
        this.eventos = response;
        this.eventosFiltrados = this.eventos;
      },
      error => console.log(error)
    );
  }
}
