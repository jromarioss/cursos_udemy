import { Controller, Get } from '@nestjs/common';
import { AppService } from './app.service';

@Controller('usuarios')// é a rota do controller se eu colocar ali '/home'
export class AppController {
  constructor(private readonly appService: AppService) {}

  @Get('/pega') // para acessar precisa de /usuarios/pega
  getHello(): string {
    return this.appService.getHello();
  }
}
