import { Component, OnInit } from '@angular/core';
import { EventoService } from '../Services/evento.Service';
import { Evento } from '../Models/Evento';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];

  public exibiImagem = true;
  public widthImg = 150;
  public marginImg = 2;
  private filtrolistado = '';

  public get filtroLista(): string {
    return this.filtrolistado
  }

  public set filtroLista(value: string) {
    this.filtrolistado = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  public filtrarEventos(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLowerCase();
    return this.eventos.filter(
      (evento: any) =>
        evento.tema.toLowerCase().indexOf(filtrarPor) !== -1 || evento.local.toLowerCase().indexOf(filtrarPor) !== -1 || evento.dataEvento.indexOf(filtrarPor) !== -1
    );
  }
  constructor(private eventoService: EventoService) { }

  public ngOnInit(): void {
    this.getEventos();
  }

  public alterarImagem(): void {
    this.exibiImagem = !this.exibiImagem;
  }

  public getEventos(): void {
    this.eventoService.getEventos().subscribe({
      next: (eventos: Evento[]) => {
        this.eventos = eventos;
        this.eventosFiltrados = this.eventos;
      },
      error: (error: any) => console.log(error)
    });
  }
}
