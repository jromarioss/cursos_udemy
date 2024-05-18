import { Module } from '@nestjs/common';
import { AppController } from './app.controller';
import { AppService } from './app.service';
import { UserModule } from './user/user.module';
// módulo é a divisão do seu projeto e nele vai o controllers e service
// decorators começa com @
@Module({
  imports: [UserModule],
  controllers: [AppController],
  providers: [AppService],
  exports: [AppService], // da acesso há quem importa o app module
})
export class AppModule {}
