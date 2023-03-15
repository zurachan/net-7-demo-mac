export class Credential {
    token: string;

    constructor(init?: Partial<Credential>) {
        Object.assign(this, init);
    }
}