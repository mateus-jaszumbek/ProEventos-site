import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-titulo',
  templateUrl: './titulo.component.html',
  styleUrl: './titulo.component.scss'
})
export class TituloComponent implements OnInit {

   @Input() titulo: string = 'ProEventos';

  constructor() { }

  ngOnInit(): void { }
}
