import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-modelportfolio',
  templateUrl: 'modelportfolio.component.html'
})
export class ModelPortfolioComponent implements OnInit {

  public testString:string="hai I am string"
  public modelPortfolio: ModelPortfolio[];
  //private http :HttpClient;
  constructor(private http: HttpClient) {
   

  }
    ngOnInit(): void {
      this.http.get<ModelPortfolio[]>("/modelportfolio").subscribe(result => {
        this.modelPortfolio = result;
        console.log(this.modelPortfolio[0])
      }, error => { console.log(error) });
    }
}
export interface Stock {
  id: number;
  name: string;
}

export interface BasketItem {
  quantity: number;
  price: number;
  oneMonthReturn: number;
  threeMonthReturn: number;
  oneYearReturn: number;
  threeYearReturn: number;
  return: number;
  stock: Stock;
}
export interface RebalancingHistory {
  date: Date;
  basketItems:BasketItem[]
}

export interface ModelPortfolio {
  portfolioId: string;
  name: string;
  owner?: any;
  basketItems: BasketItem[];
  initialValue: number;
  startDate: Date;
  rebalancingDates?: any;
  rebalancingHistory: RebalancingHistory[];
}




