export class Leiding {
    private _id: number;
    private _auth0Id: string;
    private _naam: string;
    private _voornaam: string;
    private _email: string;
    private _leidingSinds: Date;
    private _datumGestopt: Date;
    private _takId: number;

    static fromJSON(json): Leiding {
        const leiding = new Leiding(json.naam, json.voornaam, json.auth0Id, json.email, json.leidingSinds, json.datumGestopt);
        leiding._id = json.id;
        return leiding;
    }

    constructor(naam: string, voornaam: string, auth0Id?: string,  email?: string, leidingSinds?: Date, datumGestopt?: Date ) {
        this._auth0Id = auth0Id;
        this._naam = naam;
        this._voornaam = voornaam;
        this._email = email;
        this._leidingSinds = leidingSinds;
        if (this._leidingSinds === null) {
            this._leidingSinds = new Date(1, 1, 1);
        }
        this._datumGestopt = datumGestopt;
        if (this._datumGestopt === null) {
            this._datumGestopt = new Date(1, 1, 1);
        }
    }


    get naam() {
        return this._naam;
    }

    get voornaam() {
        return this._voornaam;
    }

    get email() {
        return this._email;
    }

    get leidingSinds() {
        return this._leidingSinds;
    }

    set leidingSinds(leidingSinds: Date) {
        if (leidingSinds === null) {
            this._leidingSinds = new Date(1, 1, 1);
        } else {
            this._leidingSinds = leidingSinds;
 }

    }

    get datumGestopt() {
        return this._datumGestopt;
    }

    set datumGestopt(datumGestopt: Date) {
        if (datumGestopt === null) {
            this._datumGestopt = new Date(1, 1, 1);
        } else {
            this._datumGestopt = datumGestopt;
        }
    }
    get takId() {
        return this._takId;
    }

    set takId(takId: number) {
        this._takId = takId;
    }

    toJSON() {
        return {
            auth0Id: this._auth0Id,
            naam: this.naam,
            voornaam: this._voornaam,
            email: this._email,
            takId: this._takId,
            id: this._id
        };
    }

}
