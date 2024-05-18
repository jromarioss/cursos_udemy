import { NestFactory } from '@nestjs/core';
import { AppModule } from './app.module';
import { ValidationPipe } from '@nestjs/common'
import { LogInterceptor } from './interceptors/log.interceptor';

// é a primeira função a ser executada
async function bootstrap() {
  const app = await NestFactory.create(AppModule);
  app.useGlobalPipes(new ValidationPipe()); // Configuração do pipe global
  //app.useGlobalInterceptors(new LogInterceptor) // intercepta todos os controle
  await app.listen(3000);
}
bootstrap();
