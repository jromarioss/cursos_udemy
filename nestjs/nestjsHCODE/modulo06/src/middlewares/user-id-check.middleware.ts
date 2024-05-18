import { BadRequestException, NestMiddleware } from "@nestjs/common";
import { NextFunction, Request, Response } from "express";
// para evitar coisas desnecessário como ir no banco ver se tem o user
export class UserIdCheckMiddleware implements NestMiddleware {
  //Antes de ir pro banco
  use(req: Request, res: Response, next: NextFunction) {
    //se não é um number ou id <= 0 já da o erro e nem executa o banco
    if (isNaN(Number(req.params.id)) || Number(req.params.id) <= 0) {
      throw new BadRequestException('Id inválido!');
    }

    next();
  }
}