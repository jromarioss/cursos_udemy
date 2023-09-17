import { Module } from '@nestjs/common';
import { CacheModule as CacheModules } from '@nestjs/cache-manager';
import { CityController } from './city.controller';
import { CityService } from './city.service';
import { TypeOrmModule } from '@nestjs/typeorm';
import { CityEntity } from './entity/city.entity';
import { CacheModule } from '../cache/cache.module';

@Module({
  imports: [
    CacheModules.register({
      ttl: 3600,
    }),
    CacheModule,
    TypeOrmModule.forFeature([CityEntity]),
  ],
  controllers: [CityController],
  providers: [CityService],
})
export class CityModule {}
