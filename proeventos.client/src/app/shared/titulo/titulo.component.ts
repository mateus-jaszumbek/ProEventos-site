import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-titulo',
  templateUrl: './titulo.component.html',
  styleUrl: './titulo.component.scss'
})
export class TituloComponent implements OnInit {


  @Input() titulo!: string;
  @Input() iconClass: string = 'fa fa-user';
  @Input() subtitulo: string = 'Desde 2023';

  constructor() { }

  ngOnInit(): void { }
}
