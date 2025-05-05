import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CdbResponse } from '../../interfaces/cdbResponse';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Component({
  selector: 'app-cdb',
  standalone: false,
  templateUrl: './cdb.component.html',
  styleUrl: './cdb.component.css'
})


export class CdbComponent {
  valorInicial: number = 0;
  qtdMeses: number = 0;
  valorBruto: number = 0;
  valorLiquido: number = 0;
  maximoMeses: number = 60;
  maximoInvestimnento: number = 250000;

  verificarValorMeses(): void {   
    if (this.qtdMeses > this.maximoMeses) {
      alert(`A quantidade de meses não pode exceder ${this.maximoMeses} meses`);
      this.qtdMeses = 0;
    }
  }
  verificarValorInvestimento(): void {     
    this.esconderValorBrutoEValorLiquido();
    if (this.valorInicial > this.maximoInvestimnento) {
      alert(`O Valor do Investimento  não pode ser maior que R$ 250.000,00`);
      this.valorInicial = 0;
    } 
  }

  esconderValorBrutoEValorLiquido(): void {
    this.valorBruto = 0;  
    this.valorLiquido = 0;
  }

  constructor(private readonly http: HttpClient) { }

  calcularCdb() {
    if (this.valorInicial <= 0 || this.qtdMeses <= 0) {
      alert('Valor do Investimento e Quantidade de Meses devem ser maiores que zero.');
      return;
    }
    if (this.qtdMeses > this.maximoMeses) {
      alert('Quantidade de Meses deve ser menor ou igual a 60 meses  ou 5 anos.');
      return;
    }
    if (this.valorInicial > this.maximoInvestimnento) {
      alert('Valor do Investimento deve ser menor ou igual a 250.000,00.');
      return;
    }
    this.http.post<CdbResponse>('/cdb', {valorInicial: this.valorInicial, qtdMeses: this.qtdMeses}).subscribe(
      (result) => {
        this.valorBruto = result.valorBruto;
        this.valorLiquido = result.valorLiquido;
      },
      (error) => {
        if (error.status === 400) {
          console.error('Erros de Validação:', error.error);
        } else if (error.status === 500) {
          console.error('Erro de Servidor:', error.error.message);
        } else {
          console.error('Erro Inesperado', error);
        }
      }
    );
  }
}

