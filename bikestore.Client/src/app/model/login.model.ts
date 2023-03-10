export class Login {
    email!: string;
    password!: string | null;

    constructor(init?: Partial<Login>) {
        Object.assign(this, init);
    }
}