import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import {
  Attack,
  Counter,
  Timeline
} from '../models';


@Injectable({
  providedIn: 'root'
})
export class DashboardService {
  
  constructor(private http: HttpClient) { }

  loadSeverityTableData(params: HttpParams): Observable<Attack[]> {   
     return this.http.get<Attack[]>("https://localhost:44386/severityData", {params: params});     
   }
   loadRecentTableData(params: HttpParams): Observable<Attack[]> { 
    return this.http.get<Attack[]>("https://localhost:44386/recentData", {params: params});  
  }
  loadIPGraphData(params: HttpParams): Observable<Attack[]> {   
    return this.http.get<Attack[]>("https://localhost:44386/graphData", {params: params});     
  }
  loadCounter(params: HttpParams): Observable<Counter[]> {   
    return this.http.get<Counter[]>("https://localhost:44386/counter", {params: params});     
  }
  loadTimelineData(params: HttpParams): Observable<Timeline[]> { 
    return this.http.get<Timeline[]>("https://localhost:44386/timelineData", {params: params});  
  }
}
