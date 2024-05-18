import { ExecutionContext, createParamDecorator } from "@nestjs/common";
//o context obtem o request e o response
export const ParamId = createParamDecorator((_data: string, context: ExecutionContext) => {
  return Number(context.switchToHttp().getRequest().params.id); //pega o id do params
});