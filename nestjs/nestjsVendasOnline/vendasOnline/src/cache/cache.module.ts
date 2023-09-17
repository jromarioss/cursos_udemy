import { Module } from '@nestjs/common';
import { CacheModule as CacheModules } from '@nestjs/cache-manager';
import { CacheService } from './cache.service';

@Module({
  imports: [
    CacheModules.register({
      ttl: 3600,
    }),
  ],
  providers: [CacheService],
  exports: [CacheService],
})
export class CacheModule {}
