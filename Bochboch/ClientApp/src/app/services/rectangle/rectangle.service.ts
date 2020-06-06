import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { Observable, of } from "rxjs";
import { tap, catchError } from "rxjs/operators";
import { Rectangle } from "src/app/Shared/rectangle"

@Injectable({
  providedIn: "root"
})
export class RectangleService {
  httpOptions = {
    headers: new HttpHeaders({ "Content-Type": "application/json" })
  };
    url: string = "https://localhost:44342/api/rectangle"; 
  constructor(private http: HttpClient) {
  }

  getFamilyPatient(): Observable<Rectangle[]> {
    const url = `${this.url}/rectangles`;
    return this.http.get<Rectangle[]>(url).pipe(
      tap(_ => console.log(`get rectangles`)),
      catchError(this.handleError<Rectangle[]>(`get rectangles failed`))
    );
  }

  updateFamilyPatient(rectangles: Rectangle[]): Observable<Rectangle[]> {
    const url = `${this.url}` + "/save";
    return this.http.post<Rectangle[]>(url, rectangles).pipe(
      tap(_ => console.log(`update rectangle`)),
      catchError(
        this.handleError<Rectangle[]>(
          `update rectangle`
        )
      )
    );
  }


  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T>(operation = "operation", result?: T) {
    return (error: any): Observable<T> => {
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      // this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      // Because each service method returns a different kind of Observable result,
      // handleError() takes a type parameter so it can return the safe value as the type that the app expects.
      return of(result as T);
    };
  }
}
