export class Rectangle {
  public id: number;
  public color: string;
  public y: number;
  public x: number;
  constructor(color: string, y: number, x: number, id: number) {
    this.id = id;
    this.color = color;
    this.y = y;
    this.x = x;
  }
}
