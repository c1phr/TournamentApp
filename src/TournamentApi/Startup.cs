using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using TournamentApi.Models;

namespace TournamentApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            using (var context = new TournamentContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                Game[] gameData = {
                    new Game
                    {
                        Title = "League of Legends",
                        Shortcode = "lol",
                        ImageUrl = @"http://images.everyeye.it/img-notizie/fnatic-e-il-primo-team-nella-storia-di-league-of-legend-a-terminare-la-stagione-imbattuto-233231.jpg"
                    },
                    new Game
                    {
                        Title = "Counter Strike: Global Offensive",
                        Shortcode = "csgo",
                        ImageUrl = @"http://i.ytimg.com/vi/952EewAi--s/maxresdefault.jpg"
                    },
                    new Game
                    {
                        Title = "Defense of the Ancients",
                        Shortcode = "dota",
                        ImageUrl = @"http://cdn1.wallpaperus.org/wallpapers/set1/84/2123798184-dota2.jpg"
                    }
                };
                                
                context.Games.AddRange(gameData);                               
                context.SaveChanges();
                
                Match[] matchData = 
                {
                    new Match
                    {
                        Round = 1,
                        Team1 = "Red Team",
                        Team2 = "Blue Team",
                        Status = "Finished",
                        Match_Game = context.Games.First(g => g.Shortcode == "dota")
                    },
                    new Match
                    {
                        Round = 2,
                        Team1 = "Purple Team",
                        Team2 = "Blue Team",
                        Status = "In Progress",
                        Match_Game = context.Games.First(g => g.Shortcode == "dota")
                    },
                    new Match
                    {
                        Round = 3,
                        Team1 = "TBD",
                        Team2 = "Blue Team",
                        Status = "Scheduled",
                        Match_Game = context.Games.First(g => g.Shortcode == "dota")
                    }                    
                };
                               
                context.Matches.AddRange(matchData);
                context.SaveChanges();
            }
        }

        // This method gets called by a runtime.
        // Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            // Uncomment the following line to add Web API services which makes it easier to port Web API 2 controllers.
            // You will also need to add the Microsoft.AspNet.Mvc.WebApiCompatShim package to the 'dependencies' section of project.json.
            // services.AddWebApiConventions();
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.MinimumLevel = LogLevel.Information;
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            // Add the platform handler to the request pipeline.
            app.UseIISPlatformHandler();

            // Configure the HTTP request pipeline.
            app.UseStaticFiles();

            // Add MVC to the request pipeline.
            app.UseMvc();
            // Add the following route for porting Web API 2 controllers.
            // routes.MapWebApiRoute("DefaultApi", "api/{controller}/{id?}");
        }
    }
}