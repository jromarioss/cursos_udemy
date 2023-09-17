import { createParamDecorator, ExecutionContext } from '@nestjs/common';

export const ParamId = createParamDecorator(
  (_data: unknown, context: ExecutionContext) => {
    // pegar o valor do context
    return Number(context.switchToHttp().getRequest().params.id);
  },
);
