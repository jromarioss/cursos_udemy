import { NestInterceptor, ExecutionContext, CallHandler } from "@nestjs/common";
import {Observable} from 'rxjs'
import {tap} from 'rxjs/operators'
//antes de executa cada rota intercepta aqui
export class LogInterceptor implements NestInterceptor {
  intercept(context: ExecutionContext, next: CallHandler<any>): Observable<any> | Promise<Observable<any>> {
    const dt = Date.now();
    //chama o next e o handle e o pipe e chama o tap
    return next.handle().pipe(tap(() => {
      const request = context.switchToHttp().getRequest();//para saber qual rota ta sendo acessada

      console.log(`URL: ${request.url}`);
      console.log(`Metodo: ${request.method}`);
      console.log(`Demorou: ${Date.now() - dt} milisegundos`);
    }));
  }
}