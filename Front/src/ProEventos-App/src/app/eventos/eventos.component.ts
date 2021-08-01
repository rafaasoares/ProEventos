import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  public eventosFiltrados: any = [];
  widthImg : number = 150;
  mostrarImg : boolean = true;
  private _filtroLista: string = '';

  public get filtroLista() {
    return this._filtroLista;
  }

  public set filtroLista(valeu: string) {
    this._filtroLista = valeu;
    this.eventosFiltrados = this.filtroLista
      ? this.filtrarEventos(this.filtroLista)
      : this.eventosFiltrados;
  }

  filtrarEventos(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
      || evento.local.toLocaleLowerCase().indexOf(filtrarPor)
      !== -1
    );
  }

  alterarImg() {
    this.mostrarImg = !this.mostrarImg;
  }

  constructor(private http:HttpClient) { }

  ngOnInit(): void {
    this.eventos = this.getEventos();
  }

  public getEventos():void {
    this.http.get("https://localhost:5001/Evento").subscribe(
      response => this.eventosFiltrados = this.eventos = response,
      error => console.log(error)
    );
  }
}
