import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Evento } from '../../models/Evento';
import { EventoService } from '../../services/Evento.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
  // como injetar serviço direto na classe
  //providers: [EventoService]
})
export class EventosComponent implements OnInit {

  public modalRef?: BsModalRef;

  public eventos: Evento[] = [];
  public eventosFiltrados: any = [];

  public widthImg : number = 150;
  public mostrarImg : boolean = true;
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

  public filtrarEventos(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
      || evento.local.toLocaleLowerCase().indexOf(filtrarPor)
      !== -1
    );
  }

  public alterarImg(): void {
    this.mostrarImg = !this.mostrarImg;
  }

  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService) {
  }

  public ngOnInit(): void {
    //this.eventos = this.getEventos();
    this.spinner.show();
    this.getEventos();
  }

  public getEventos(): void {
    this.eventoService.getEventos().subscribe({
      next: (eventosResp: Evento[]) => {
        this.eventosFiltrados = this.eventos = eventosResp
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao carregar os eventos.', 'Error!');
      },
      complete: () => this.spinner.hide()
    });
  }

  public openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  public confirm(): void {
    if (this.modalRef)
      this.modalRef.hide();
      this.toastr.success('O evento foi deletado com sucesso.', 'Deletado!');
  }

  public decline(): void {
    if(this.modalRef)
      this.modalRef.hide();
  }
}
