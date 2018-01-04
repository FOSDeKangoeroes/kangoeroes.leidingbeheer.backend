export class Leiding {
    private _id: number;
    private _auth0Id: string;
    private _naam: string;
    private _voornaam: string;
    private _email: string;
    private _leidingSinds: Date;
    private _datumGestopt: Date;

    static fromJSON(json): Leiding {
        const leiding = new Leiding(json.auth0Id, json.naam, json.voornaam, json.email, json.leidingSinds, json.datumGestopt);
        leiding._id = json.id;
        return leiding;
    }

    constructor(auth0Id: string, naam: string, voornaam: string, email: string, leidingSinds: Date, datumGestopt: Date ) {
        this._auth0Id = auth0Id;
        this._naam = naam;
        this._voornaam = voornaam;
        this._email = email;
        this._leidingSinds = leidingSinds;
        this._datumGestopt = datumGestopt;
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

    get datumGestopt() {
        return this._datumGestopt;
    }

}