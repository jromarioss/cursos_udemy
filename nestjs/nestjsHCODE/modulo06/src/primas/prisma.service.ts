import { INestApplication, Injectable, OnModuleInit } from '@nestjs/common';
import { PrismaClient } from '@prisma/client';

@Injectable()
export class PrismaService extends PrismaClient implements OnModuleInit {
  async onModuleInit() {
    await this.$connect();//abre conexão antes de usar o prisma
  }

  async enableShutDownHooks(app: INestApplication) {
    process.on('beforeExit', async () => {
      await app.close();//fecha conexão depois de usar o prisma
    });
  }
}