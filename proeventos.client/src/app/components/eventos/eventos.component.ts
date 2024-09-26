import { Component, OnInit, TemplateRef } from '@angular/core';

import { ToastrService } from 'ngx-toastr';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';

import { EventoService } from '../../services/evento.Service';
import { Evento } from '../../models/Evento';


@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  modalRef!: BsModalRef;

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
  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
  ) { }

  public ngOnInit(): void {
    this.getEventos();

    this.spinner.show();

    setTimeout(() => {

    }, 5000);
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
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao carregar os eventos', 'Erro!');
        console.error(error);
      },
      complete: () => this.spinner.hide()
    });
  }

  public openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  public confirm(): void {
    this.modalRef.hide();
    this.toastr.success('O evento foi deletado com sucesso!', 'Deletado!');
  }

  public decline(): void {
    this.modalRef.hide();
  }

}
