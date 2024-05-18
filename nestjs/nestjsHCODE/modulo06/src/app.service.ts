import { Injectable } from '@nestjs/common';
// é onde fica a lógica da api
@Injectable()
export class AppService {
  getHello(): string {
    return 'Hello World!';
  }
}
