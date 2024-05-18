import { MiddlewareConsumer, Module, NestModule, RequestMethod } from '@nestjs/common';
import { UserController } from './user.controller';
import { UserService } from './user.service';
import { PrismaModule } from '../primas/prisma.module';
import { UserIdCheckMiddleware } from '../middlewares/user-id-check.middleware';

@Module({
  imports: [PrismaModule],
  controllers: [UserController],
  providers: [UserService],
  exports: [],
})
export class UserModule implements NestModule {//usar o nest Module ai obriga nos a usar o configure para usar o middleware
  configure(consumer: MiddlewareConsumer) {
    consumer.apply(UserIdCheckMiddleware).forRoutes({//manda para rotas
      path: 'users/:id',
      method: RequestMethod.ALL//pega todo os metodos
    });//aplica o middleware que vc quer usar
  }
}