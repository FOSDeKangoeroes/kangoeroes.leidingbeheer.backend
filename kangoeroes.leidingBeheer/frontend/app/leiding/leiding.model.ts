export class Leiding {
    private _id: number;
    private _auth0Id: string;
    private _naam: string;
    private _voornaam: string;
    private _email: string;
    private _leidingSinds: Date;
    private _datumGestops: Date;

    get naam() {
        return this._naam;
    }

}